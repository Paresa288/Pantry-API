import { Component, inject, OnInit, signal } from '@angular/core';
import { FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms';
import { ItemsServiceService } from '../../shared/services/items.service';
import { LocationsService } from '../../shared/services/locations.service';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { CategoriesService } from '../../shared/services/categories.service';
import { Item } from '../../types/item';
import { Category } from '../../types/category';
import { Location } from '../../types/location';
import { debounceTime, distinctUntilChanged } from 'rxjs';

@Component({
  selector: 'app-add-item-form',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './add-item-form.component.html',
  styles: ''
})
export class AddItemFormComponent implements OnInit {
  activeModal = inject(NgbActiveModal);

  categories = signal<Category[]>([]);
  filteredCategories = signal<Category[]>([]);
  locations = signal<Location[]>([]);
  filteredLocations = signal<Location[]>([]);
  
  private itemsService = inject(ItemsServiceService);
  private locationsService = inject(LocationsService);
  private categoriesService = inject(CategoriesService);
  
  // Formulario reactivo
  addItemForm : FormGroup = new FormGroup({
    name: new FormControl('', { nonNullable: true }),
    unit: new FormControl('', { nonNullable: true }),
    stock: new FormControl(0, { nonNullable: true }),
    expirationDate: new FormControl('', { nonNullable: true }),
    
    category: new FormGroup({
      id: new FormControl<string | null>(null),
      catName: new FormControl('', { nonNullable: true }),
      catDescription: new FormControl('', { nonNullable: true }),
    }),
    
    location: new FormGroup({
      id: new FormControl<string | null>(null),
      locName: new FormControl('', { nonNullable: true }),
      locDescription: new FormControl('', { nonNullable: true }),
    }),
  });
  
  ngOnInit() : void{
    this.loadLocations();
    this.loadCategories();
    
    this.addItemForm.get('category.catName')?.valueChanges
    .pipe(debounceTime(200), distinctUntilChanged())
    .subscribe(query => this.filterCategories(query || ''));
  }
  
  loadCategories() {
    this.categoriesService.getCategories().subscribe(cats => {
      this.categories.set(cats);
      this.filterCategories(this.addItemForm.get('category.catName')?.value || '');
    });
  }
  
  loadLocations() {
    this.locationsService.getLocations().subscribe( locs => {
      this.locations.set(locs);
    });
  }
  
  selectCategory(cat: Category) {
    this.addItemForm.patchValue({
      category: {
        id: cat.id,
        catName: cat.name,
        catDescription: cat.description || ''
      }
    });
    this.filteredCategories.set([]);
  }

  createNewCategory(): void {
    const name = this.addItemForm.get('category.catName')?.value?.trim();
    const description = this.addItemForm.get('category.catDescription')?.value?.trim() || '';

    if (!name || this.categories().some(c => c.name.toLowerCase() === name.toLowerCase())) {
      return;
    }
    const newCat: Partial<Category> = { name, description };
    this.categoriesService.createCategory(newCat as Category)
      .subscribe(createdCat => {
        this.categories.update(cats => [...cats, createdCat]);
        this.selectCategory(createdCat);
      });
  }
    
    
  private filterCategories(query: string) {
    const lower = query.toLowerCase().trim();
    if (!lower) {
      this.filteredCategories.set([]);
      return;
    }
    this.filteredCategories.set(
      this.categories().filter(c => c.name.toLowerCase().includes(lower))
    );
  }


  onSubmit() {
    if (this.addItemForm.invalid) return;
    const formValue = this.addItemForm.getRawValue();

    const item: Partial<Item> = {
      name: this.addItemForm.value.name,
      unit: this.addItemForm.value.unit,
      expDate: this.addItemForm.value.expirationDate,
      categoryId: this.addItemForm.value.category.id, 
      locationId: this.addItemForm.value.location.id
    };
    this.activeModal.close(item);
  };
}

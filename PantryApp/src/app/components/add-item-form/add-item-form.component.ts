import { Component, inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms';
import { ItemsServiceService } from '../../shared/services/items.service';
import { LocationsService } from '../../shared/services/locations.service';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { CategoriesService } from '../../shared/services/categories.service';

@Component({
  selector: 'app-add-item-form',
  imports: [ReactiveFormsModule],
  templateUrl: './add-item-form.component.html',
  styles: ''
})
export class AddItemFormComponent implements OnInit {
  activeModal = inject(NgbActiveModal);

  constructor(public itemsService: ItemsServiceService, public locationsService: LocationsService, public categoriesService: CategoriesService) {}
  ngOnInit() : void{
    this.getLocations();
    this.getCategories();
  }
  
  getCategories() {
    this.categoriesService.getCategories().subscribe({
      next: (res) => {
        this.categoriesService.categories = res;
      },
      error: (e) => {
        console.log(e);
      }
    });
  }

  getLocations() {
    this.locationsService.getLocations().subscribe({
      next: (res) => {
        this.locationsService.locations = res;
      },
      error: (e) => {
        console.log(e);
      }
    });
  }

  addItemForm : FormGroup = new FormGroup({
    name: new FormControl(''),
    unit: new FormControl(''),
    stock: new FormControl(0),
    expirationDate: new FormControl(Date()),
    category: new FormControl(),
    location: new FormControl(),
  });
  


  onSubmit() {
    const item = {
      id: this.addItemForm.value.id, 
      name: this.addItemForm.value.name,
      categoryId: this.addItemForm.value.category.id, 
      unit: this.addItemForm.value.unit,
      expirationDate: this.addItemForm.value.expirationDate
    };
    
    const USLId = this.addItemForm.value.USLId;
    const stock = this.addItemForm.value.stock
    
    this.itemsService.createItem(item, USLId, stock).subscribe({
      next: (res) => {
        console.log("Item created successfully:", res);
        this.itemsService.items.push(res);
      },
      error: (e) => {
        console.log("Error creating item:", e);
      }
    });
    this.addItemForm.reset();
  };
}

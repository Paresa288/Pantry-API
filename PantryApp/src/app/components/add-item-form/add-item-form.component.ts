import { Component, inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms';
import { ItemsServiceService } from '../../shared/services/items.service';
import { LocationsService } from '../../shared/services/locations.service';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Location } from '../../types/location';

@Component({
  selector: 'app-add-item-form',
  imports: [ReactiveFormsModule],
  templateUrl: './add-item-form.component.html',
  styles: ''
})
export class AddItemFormComponent implements OnInit {
  activeModal = inject(NgbActiveModal);

  constructor(public itemsService: ItemsServiceService, public locationsService: LocationsService) {}
  ngOnInit() : void{
    this.getLocations();
  }

  getLocations() {
    this.locationsService.getLocations().subscribe({
      next: (res) => {
        this.locationsService.locations = res;
        console.log(res);
      },
      error: (e) => {
        console.log(e);
      }
    });
  }

  addItemForm : FormGroup = new FormGroup({
    name: new FormControl(''),
    category: new FormControl(0),
    unit: new FormControl(''),
    expirationDate: new FormControl(Date()),
    USLId: new FormControl(),
    stock: new FormControl(0)
  });
  


  onSubmit() {
    
    const item = {
      id: this.addItemForm.value.id, 
      name: this.addItemForm.value.name,
      categoryId: this.addItemForm.value.category,
      unit: this.addItemForm.value.unit,
      expirationDate: this.addItemForm.value.expirationDate
    };
    
    const USLId = this.addItemForm.value.USLId;
    const stock = this.addItemForm.value.stock
    
    this.itemsService.createItem(item, USLId, stock).subscribe({
      next: (res) => {
        console.log("Item created successfully:", res);
      },
      error: (e) => {
        console.log("Error creating item:", e);
      }
    });
    this.addItemForm.reset();
  };
}

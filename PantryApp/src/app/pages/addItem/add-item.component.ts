import { Component } from '@angular/core';
import { FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-add-item',
  imports: [ReactiveFormsModule],
  templateUrl: './add-item.component.html',
  styleUrl: './add-item.component.css'
})
export class AddItemComponent {
  addItemForm = new FormGroup({
    itemName: new FormControl(''),
    category: new FormControl(''),
    unit: new FormControl(''),
    expirationDate: new FormControl('')
  });

  onSubmit() {
    console.log(this.addItemForm.value);
  }
}

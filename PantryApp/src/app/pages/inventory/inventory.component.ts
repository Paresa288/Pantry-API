import { Component, signal } from '@angular/core';
import { ItemsListComponent } from '../../components/items-list/items-list.component';
import { AddItemFormComponent } from "../../components/add-item-form/add-item-form.component";

@Component({
  selector: 'app-inventory',
  imports: [ItemsListComponent, AddItemFormComponent],
  templateUrl: './inventory.component.html',
  styleUrl: './inventory.component.css'
})
export class InventoryComponent {
  class = "d-none"
  
  ChangeVisibility() {
    if (this.class === "d-none") {
      this.class = ""
    } else {
      this.class = "d-none"
    }
  }

}

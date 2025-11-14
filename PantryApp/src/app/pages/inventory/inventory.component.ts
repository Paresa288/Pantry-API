import { Component, inject } from '@angular/core';
import { ItemsListComponent } from '../../components/items-list/items-list.component';
import { AddItemFormComponent } from "../../components/add-item-form/add-item-form.component";
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-inventory',
  imports: [ItemsListComponent],
  templateUrl: './inventory.component.html',
  styles: ''
})

export class InventoryComponent {
  private modalService = inject(NgbModal);
  
  open() {
    this.modalService.open(AddItemFormComponent);
  }
}

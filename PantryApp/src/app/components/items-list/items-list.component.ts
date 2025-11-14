import { Component, OnInit } from '@angular/core';
import { ItemComponent } from '../item/item.component';
import { ItemsServiceService } from '../../shared/services/items.service';
import { Item } from '../../types/item';

@Component({
  selector: 'app-items-list',
  standalone: true,
  imports: [ItemComponent],
  templateUrl: './items-list.component.html',
  styles: ''
})
export class ItemsListComponent implements OnInit {
  constructor(public itemsService: ItemsServiceService) {}

  ngOnInit(): void {
    this.getItems();
  }

  getItems() {
    this.itemsService.getItems().subscribe({
      next: (res) => {
        this.itemsService.items = res;
      },
      error: (e) => {
        console.log(e);
      }
    });
  };

  createItem(item : Item, USLId: number, stock: number) {
    this.itemsService.createItem(item, USLId, stock).subscribe({
      next: (res) => {
        console.log("Item created successfully:", res);
        this.getItems(); // Refresh the items list after creation
      },
      error: (e) => {
        console.log("Error creating item:", e);
      }
    });
  };
  
  deleteItem(id : number) {
    this.itemsService.deleteItem(id).subscribe({
      next: (res) => {
        console.log("Item deleted successfully:", res);
        this.getItems();
      },
      error: (e) => {
        console.log("Error deleting item:", e);
      }
    });
  };
}

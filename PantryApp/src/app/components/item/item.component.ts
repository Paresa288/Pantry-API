import { Component, Input } from '@angular/core';
import { Item } from '../../types/item';
import { ItemsServiceService } from '../../shared/services/items.service';

@Component({
  selector: 'app-item',
  standalone: true,
  imports: [],
  templateUrl: './item.component.html',
  styles: '',
})
export class ItemComponent {
  @Input() item!:Item;
  
  constructor(public itemsService : ItemsServiceService) {
    this.itemsService = itemsService;
  }
  
  deleteItem() {
    this.itemsService.deleteItem(this.item.id).subscribe({
      next: (res) => {
        console.log("Item deleted successfully:", res);
        // Optionally, you might want to refresh the items list or notify the parent component
      },
      error: (e) => {
        console.log("Error deleting item:", e);
      }
    });
  }
}

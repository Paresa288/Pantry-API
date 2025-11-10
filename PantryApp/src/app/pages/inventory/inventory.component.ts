import { Component } from '@angular/core';
import { ItemsListComponent } from '../../components/items-list/items-list.component';

@Component({
  selector: 'app-inventory',
  imports: [ItemsListComponent],
  templateUrl: './inventory.component.html',
  styleUrl: './inventory.component.css'
})
export class InventoryComponent {
  
}

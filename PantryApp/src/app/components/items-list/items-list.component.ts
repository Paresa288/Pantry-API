import { Component, EventEmitter, input, output } from '@angular/core';
import { ItemComponent } from '../item/item.component';
import { Item } from '../../types/item';

@Component({
  selector: 'app-items-list',
  standalone: true,
  imports: [ItemComponent],
  templateUrl: './items-list.component.html',
  styles: ''
})

export class ItemsListComponent {
  items = input<Item[]>();
  delete = output<number>();

  onDelete(id:number) {
    this.delete.emit(id);
  }
}

import { Component, EventEmitter, input, Input, output, Output } from '@angular/core';
import { Item } from '../../types/item';

@Component({
  selector: 'app-item',
  standalone: true,
  imports: [],
  templateUrl: './item.component.html',
  styles: '',
})
export class ItemComponent {
  item = input.required<Item>();
  delete = output<number>();

}

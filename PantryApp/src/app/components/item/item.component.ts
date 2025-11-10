import { Component, Input } from '@angular/core';
import { Item } from '../../types/item';

@Component({
  selector: 'app-item',
  standalone: true,
  imports: [],
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css']
})
export class ItemComponent {
  @Input() item!:Item;
}

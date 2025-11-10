import { Component, OnInit } from '@angular/core';
import { ItemComponent } from '../item/item.component';
import { ItemsServiceService } from '../../shared/services/items-service.service';

@Component({
  selector: 'app-items-list',
  standalone: true,
  imports: [ItemComponent],
  templateUrl: './items-list.component.html',
  styleUrls: ['./items-list.component.css']
})
export class ItemsListComponent implements OnInit {
  constructor(public itemsService: ItemsServiceService) {}

  ngOnInit(): void {
    this.getItems()
  }

  getItems() {
    this.itemsService.getItems().subscribe({
      next: (res) => {
        this.itemsService.items = res;
      },
      error: (e) => {
        console.log(e);
      }
    })
  
  }
}

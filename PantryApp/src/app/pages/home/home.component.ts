import { Component, inject, OnInit, signal } from '@angular/core';
import { LocationsService } from '../../shared/services/locations.service';
import { ItemsServiceService } from '../../shared/services/items.service';
import { ItemsListComponent } from '../../components/items-list/items-list.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AddItemFormComponent } from '../../components/add-item-form/add-item-form.component';
import { Item } from '../../types/item';

@Component({
  selector: 'app-home',
  imports: [ItemsListComponent],
  templateUrl: './home.component.html',
  styles: ''
})
export class HomeComponent implements OnInit {
  items = signal<Item[]>([]);
  private modalService = inject(NgbModal);
  
  constructor (public locationsService:LocationsService, public itemsService:ItemsServiceService){};
  
  ngOnInit(): void {
    this.getLocations();
    this.getItems();
  };
  
  getItems() {
    this.itemsService.getItems().subscribe({
      next: (res) => {
        this.items.set(res);
      },
      error: (e) => {
        console.log(e);
      }
    });
  };

  getLocations() {
    this.locationsService.getLocations().subscribe({
      next: (res) => {
        this.locationsService.locations = res;
      },
      error: (e) => {
        console.error(e);
      }
    });
  };
  
  onDeleteItem(id:number) {
    this.itemsService.deleteItem(id).subscribe({
      next: (res) => {
        console.log("Item deleted successfully:", res);
        this.items.set(this.items().filter(i => i.id !== id)); 
      },
      error: (e) => {
        console.log("Error deleting item:", e);
      }
    });
  };
  
  open() {
    this.modalService.open(AddItemFormComponent);
  };
}

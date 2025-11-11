import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { UserComponent } from './pages/user/user.component';
import { InventoryComponent } from './pages/inventory/inventory.component';

export const routes: Routes = [
  {path: '', redirectTo: 'home', pathMatch: 'full' },
  {path: 'home', component: HomeComponent},
  {path: 'user/:userId', component: UserComponent},
  {path: 'inventory/:userId', component: InventoryComponent},
];

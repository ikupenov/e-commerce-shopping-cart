import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProductGridComponent } from '@app/modules/shop';
import { CartComponent } from '@app/modules/cart';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: ProductGridComponent
  },
  { path: 'cart', component: CartComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

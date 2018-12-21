import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedModule } from '@app/shared';

import { ProductGridComponent } from './product-grid/product-grid.component';
import { ProductGridItemComponent } from './product-grid-item/product-grid-item.component';

@NgModule({
  declarations: [ProductGridComponent, ProductGridItemComponent],
  imports: [
    CommonModule,
    SharedModule
  ]
})
export class ShopModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShopComponent } from 'src/app/shop/shop.component';
import { ProductDetailsComponent } from 'src/app/shop/product-details/product-details.component';

const routes: Routes = [
  { path: '', component: ShopComponent },
  {
    path: ':id',
    component: ProductDetailsComponent,
    data: { breadcrumb: { alias: 'productDetails' } },
  },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ShopRoutingModule {}

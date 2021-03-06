import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './admin.component';
import { EditProductComponent } from './edit-product/edit-product.component';
import { AdminRoutingModule } from 'src/app/admin/admin-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';



@NgModule({
  declarations: [AdminComponent, EditProductComponent],
  imports: [CommonModule, SharedModule, AdminRoutingModule],
})
export class AdminModule {}

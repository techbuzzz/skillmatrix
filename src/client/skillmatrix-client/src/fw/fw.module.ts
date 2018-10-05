import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { FooterComponent } from './common/footer/footer.component';
import { SidebarComponent } from './common/sidebar/sidebar.component';
import { TopnavbarComponent } from './common/topnavbar/topnavbar.component';


@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    FormsModule  
  ],
  declarations: [
    FooterComponent,
    SidebarComponent,
    TopnavbarComponent
  ]
})
export class FwModule { }

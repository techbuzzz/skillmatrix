import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { FooterComponent } from './common/footer/footer.component';
import { SidebarComponent } from './common/sidebar/sidebar.component';
import { TopnavbarComponent } from './common/topnavbar/topnavbar.component';
import { ContentComponent } from './common/content/content.component';
import { PageContentComponent } from './page-content/page-content.component';


@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    FormsModule  
  ],
  declarations: [
    FooterComponent,
    SidebarComponent,
    TopnavbarComponent,
    ContentComponent,
    PageContentComponent
  ],
  exports:[
    PageContentComponent
  ]
})
export class FwModule { }

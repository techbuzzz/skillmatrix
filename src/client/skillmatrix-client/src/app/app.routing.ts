import { Routes, RouterModule } from '@angular/router';

import { NgModule } from '@angular/core';
import { SkillsComponent } from './skills/skills.component';
import { DashboardComponent } from './dashboard/dashboard.component';


export const appRoutes: Routes = [
    // redirect root to the dasbhoard route
    { path: '', component: DashboardComponent},
   { path: '**', component: DashboardComponent },

    { path: 'skills', component: SkillsComponent },
];

// define a module
@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }

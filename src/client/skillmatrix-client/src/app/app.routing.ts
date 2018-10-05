import { Routes, RouterModule } from '@angular/router';

import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MainDashboardComponent } from './dashboard/main-dashboard/main-dashboard.component';


export const appRoutes: Routes = [
    // redirect root to the dasbhoard route
    { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
    {
        path: 'dashboard', component: DashboardComponent, children: [
            {
                path: '', redirectTo: '/main', pathMatch: 'full'
            },
            {
                path: 'main', component: MainDashboardComponent
            }
        ]
    },
    { path: '**', component: DashboardComponent },
];

// define a module
@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PrivateLayoutComponent } from './layouts/private/private-layout.component';
import { PublicLayoutComponent } from './layouts/public/public-layout.component';
import { PRIVATE_ROUTES } from './routes/private.routes';
import { PUBLIC_ROUTES } from './routes/public.routes';

const routes: Routes = [
    {
        path: '',
        component: PublicLayoutComponent,
        children: PUBLIC_ROUTES
    },
    {
        path: '',
        component: PrivateLayoutComponent,
        children: PRIVATE_ROUTES
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }

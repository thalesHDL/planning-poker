import { Routes } from "@angular/router"

export const PUBLIC_ROUTES: Routes = [
    {
        path: '',
        loadChildren: () => import(`../views/home/home.module`).then(module => module.HomeModule),
    },
    {
        path: 'register',
        loadChildren: () => import(`../views/register/register.module`).then(module => module.RegisterModule),
    },
    {
        path: 'login',
        loadChildren: () => import(`../views/login/login.module`).then(module => module.LoginModule),
    }
]

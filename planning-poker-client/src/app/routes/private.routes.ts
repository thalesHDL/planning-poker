import { Routes } from "@angular/router"

export const PRIVATE_ROUTES: Routes = [
    {
        path: 'game/:id',
        loadChildren: () => import(`../views/game/game.module`).then(module => module.GameModule),
    }
]

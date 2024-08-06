import { Routes } from '@angular/router';
import { PlayersComponent } from './pages/players/players.component';
import { MessagesComponent } from './pages/messages/messages.component';

export const routes: Routes = [
    // {
    //     path: 'profile/:id',
    //     loadComponent: () => import('./pages/profile/profile.component').then(m => m.ProfileComponent),
    //     title: (route: ActivatedRouteSnapshot) => `Gem Finder | Profile for ${route.paramMap.get('id')}`
    // },
    {
        path: 'players',
        component: PlayersComponent,
        title: 'Gem Finder | All Players',
        data: { preload: true }
    },
    // {
    //     path: 'leaderboards',
    //     loadChildren: () => import('./pages/leaderboards/leaderboards.module').then(m => m.LeaderboardsModule),
    //     title: 'Gem Finder | Leaderboards'
    // },
    {
         path: 'messages',
         component: MessagesComponent,
         //loadComponent: () => import('./pages/messages/messages.component').then(m => m.MessagesComponent),
         data: { preload: true }
    },
    {
        path: '',
        redirectTo: `/players`,
        pathMatch: 'full',
    },
    {
        path: '**',
        redirectTo: '/players'
    }
];

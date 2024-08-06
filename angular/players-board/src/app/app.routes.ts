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
    {
         path: 'leaderboards',
         loadComponent: () => import('./pages/leaderboards/leaderboards.component').then(m => m.LeaderboardsComponent),
         title: 'Gem Finder | Leaderboards'
    },
    {
         path: 'messages',
         loadComponent: () => import('./pages/messages/messages.component').then(m => m.MessagesComponent),
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

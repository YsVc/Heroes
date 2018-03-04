import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HeroListComponent } from './hero-list/hero-list.component';
import { HeroDetailsComponent } from './hero-details/hero-details.component';
import { PlayerListComponent } from './player-list/player-list.component';
import { MatchListComponent } from './match-list/match-list.component';

const routes: Routes = [
  { path: 'heroes', component: HeroListComponent },
  { path: 'heroes/:name', component: HeroDetailsComponent },
  { path: 'players', component: PlayerListComponent },
  { path: 'matches', component: MatchListComponent },
  { path: '', redirectTo: '/heroes', pathMatch: 'full'}
];


@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }

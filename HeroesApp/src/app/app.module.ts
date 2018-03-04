import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { OrderModule } from 'ngx-order-pipe';

import { AppComponent } from './app.component';
import { HeroesService } from './heroes.service';
import { AppRoutingModule } from './/app-routing.module';
import { HeroListComponent } from './hero-list/hero-list.component';
import { HeroDetailsComponent } from './hero-details/hero-details.component';
import { PlayerListComponent } from './player-list/player-list.component';
import { MatchListComponent } from './match-list/match-list.component';
import { SecondsConverterPipe } from './pipes/seconds-converter.pipe';

@NgModule({
  declarations: [
    AppComponent,
    HeroListComponent,
    HeroDetailsComponent,
    PlayerListComponent,
    MatchListComponent,
    SecondsConverterPipe
  ],
  imports: [
    NgbModule.forRoot(),
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    OrderModule
  ],
  providers:
  [
    HeroesService,
    //{
    //  provide: APP_INITIALIZER, 
    //  useFactory: heroesProviderFactory,
    //  multi: true
    //}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function heroesProviderFactory(provider: HeroesService) {
  return () => provider.load();
}

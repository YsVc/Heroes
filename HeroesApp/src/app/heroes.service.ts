import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'

import { Hero } from './hero'
import { Player } from './player'
import { Match } from './match'

@Injectable()
export class HeroesService {

  constructor(private http: HttpClient) { }

  private heroes: Observable<Hero[]>;

  public getHeroes() : Observable<Hero[]> {
    return this.http.get<Hero[]>('api/heroes').map(h => h.map(hh => new Hero().deserialize(hh)));
  }

  public getHeroesDetailed(): Observable<Hero[]> {
    return this.http.get<Hero[]>('api/heroes/detailed').map(h => h.map(hh => new Hero().deserialize(hh)));
  }

  public getPlayers(): Observable<Player[]> {
    return this.http.get<Player[]>('api/players/detailed').map(p => p.map(pp => new Player().deserialize(pp)));
  }

  public getMatches(): Observable<Match[]> {
    return this.http.get<Match[]>('api/matches').map(p => p.map(pp => new Match().deserialize(pp)));
  }

  load() {
    this.heroes = this.http.get<Hero[]>('api/heroes');
  }
}

import { Component, OnInit } from '@angular/core';
import { HeroesService } from '../heroes.service';
import { Hero } from '../hero'

@Component({
  selector: 'app-hero-list',
  templateUrl: './hero-list.component.html',
  styleUrls: ['./hero-list.component.css']
})
export class HeroListComponent implements OnInit {

  private heroes: Hero[];
  private sortKey: string = 'winrate';
  private sortIsReversed: boolean = true;

  private maxKda: number;
  private maxWinrate: number;
  private maxPopularity: number;

  constructor(private heroesService: HeroesService) { }

  ngOnInit() {
    this.heroesService.getHeroesDetailed().subscribe(result => {
      this.heroes = result;
      this.maxKda = Math.max.apply(Math, this.heroes.map(h => h.kdaRatio));
      this.maxWinrate = Math.max.apply(Math, this.heroes.map(h => h.winrate));
      this.maxPopularity = Math.max.apply(Math, this.heroes.map(h => h.popularity));
    });
  }

  setOrder(key: string) {
    if (this.sortKey === key) {
      this.sortIsReversed = !this.sortIsReversed;
    }

    this.sortKey = key;
  }
}

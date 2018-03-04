import { Component, OnInit } from '@angular/core';
import { HeroesService } from '../heroes.service';
import { Player } from '../player';

@Component({
  selector: 'app-player-list',
  templateUrl: './player-list.component.html',
  styleUrls: ['./player-list.component.css']
})
export class PlayerListComponent implements OnInit {

  private players: Player[];
  private sortKey: string = 'winrate';
  private sortIsReversed: boolean = true;

  private maxKda: number;
  private maxWinrate: number;

  constructor(private heroesService: HeroesService) { }

  ngOnInit() {
    this.heroesService.getPlayers().subscribe(result => {
      this.players = result;
      this.maxKda = Math.max.apply(Math, this.players.map(p => p.kdaRatio));
      this.maxWinrate = Math.max.apply(Math, this.players.map(p => p.winrate));
    });


  }

  setOrder(key: string) {
    if (this.sortKey === key) {
      this.sortIsReversed = !this.sortIsReversed;
    }

    this.sortKey = key;
  }
}

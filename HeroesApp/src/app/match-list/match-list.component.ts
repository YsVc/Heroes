import { Component, OnInit } from '@angular/core';
import { HeroesService } from '../heroes.service';
import { Match } from '../match';

@Component({
  selector: 'app-match-list',
  templateUrl: './match-list.component.html',
  styleUrls: ['./match-list.component.css']
})
export class MatchListComponent implements OnInit {

  private matches: Match[];
  private selectedMatch: number = 0;

  constructor(private heroesService: HeroesService) {

  }

  ngOnInit() {
    this.heroesService.getMatches().subscribe(result => {
      this.matches = result;
      console.log(this.matches);
    });
  }

  private selectMatch(id: number) {
    if (this.selectedMatch === id) {
      this.selectedMatch = 0;
      return;
    }

    this.selectedMatch = id;
  }
}

import { Component, OnInit } from '@angular/core';
import { Player } from '../../interfaces/player';
import { Observable, of } from 'rxjs';
import { ApiService } from '../../services/api.service';
import { OnlineStatusDirective } from '../../directives/online-status.directive';
import { RouterModule } from '@angular/router'; 
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-players',
  standalone: true,
  imports: [CommonModule, OnlineStatusDirective, RouterModule],
  templateUrl: './players.component.html',
  styleUrl: './players.component.css'
})
export class PlayersComponent implements OnInit {
  public players$: Observable<Player[] | undefined> = of(undefined);

  constructor(
    private api: ApiService
  ) { }

  public ngOnInit(): void {
    this.players$ = this.api.getAllPlayers$();
  }

  public update(text: string) {
    this.players$ = this.api.getPlayersByName$(text);
  }
}
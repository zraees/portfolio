import { Component, OnInit } from '@angular/core';
import { map, Observable, of, switchMap } from 'rxjs';
import { Player } from '../../interfaces/player';
import { ApiService } from '../../services/api.service';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';
import { OnlineStatusDirective } from '../../directives/online-status.directive';
import { JoinPipe } from '../../pipes/join.pipe';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [CommonModule, OnlineStatusDirective, JoinPipe],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent implements OnInit {
  public player$: Observable<Player | undefined> = of(undefined);

  constructor(
    private api: ApiService,
    private route: ActivatedRoute
  ) { }

  public ngOnInit(): void {
    this.player$ = this.route.paramMap.pipe(
      map(params => params.get('id') ?? ''),
      switchMap(id => this.api.getPlayerById$(id))
    );
  }

}
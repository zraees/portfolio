import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Player } from '../interfaces/player';
import { delay, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(
    private http: HttpClient
  ) { }

  public getAllPlayers$() {
    return this.http.get<Player[]>('/assets/mocks/players.json').pipe(delay(1000));
  }

  public getPlayerById$(id: string) {
    return this.getAllPlayers$().pipe(
      map(players => players.find(player => player.id === id))
    );
  }

  public getPlayersByName$(text: string) {
    return this.getAllPlayers$().pipe(
      map(players => players.filter(player => player.name.toLowerCase().includes(text.toLowerCase())))
    );
  }
}
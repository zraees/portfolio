import { Component } from '@angular/core';
import { HighScoresComponent } from '../../components/high-scores/high-scores.component';
import { MostGemsComponent } from '../../components/most-gems/most-gems.component';

@Component({
  selector: 'app-leaderboards',
  standalone: true,
  imports: [HighScoresComponent, MostGemsComponent],
  templateUrl: './leaderboards.component.html',
  styleUrl: './leaderboards.component.css'
})
export class LeaderboardsComponent {

}

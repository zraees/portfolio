import { Component } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { MessageService } from './services/message.service';
import { environment } from '../environments/environment';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, RouterModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'players-board';
  public appFooter = environment.appFooter;

  constructor(
    public messageService: MessageService
  ){

  }
}

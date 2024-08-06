import { CommonModule } from '@angular/common';
import { Component, effect } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { MessageService } from '../../services/message.service';

@Component({
  selector: 'app-messages',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './messages.component.html',
  styleUrl: './messages.component.css'
})
export class MessagesComponent {

  constructor(
    private title: Title,
    public messageService: MessageService
  ) {
    effect(() => {
      this.title.setTitle(`Gem Finder | Messages (${this.messageService.count()})`);
    });
  }

}
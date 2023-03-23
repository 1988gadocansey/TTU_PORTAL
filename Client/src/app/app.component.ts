import { Component } from '@angular/core';
import { AuthenticationService } from './core/services/authentication.service';
import { ThemeService } from './core/services/theme.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'TTU Portal';

  constructor(public themeService: ThemeService, private authService: AuthenticationService) { }
  ngOnInit(): void {
    if (this.authService.isUserAuthenticated())
      this.authService.sendAuthStateChangeNotification(true);
  }
}

import { Component } from '@angular/core';
import { AuthService } from '../../core/services/auth.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.sass']
})
export class NavbarComponent {

  isAuthenticated = false;
  name = '';

  constructor(private authService: AuthService, public translate: TranslateService) {
    translate.addLangs(['en', 'ua']);
    translate.setDefaultLang('en');

    const browserLang = translate.getBrowserLang();
    // @ts-ignore
    translate.use(browserLang.match(/en|ua/) ? browserLang : 'en');
  }

  ngOnInit() {
    this.isAuthenticated = this.authService.isAuthenticated();
    this.name = localStorage.getItem('userName') as string;
  }

  logout() {
    this.authService.logout();
  }
}

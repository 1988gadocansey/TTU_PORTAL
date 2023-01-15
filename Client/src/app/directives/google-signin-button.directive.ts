import { SocialAuthService } from '@abacritt/angularx-social-login';
import { Directive, ElementRef, Input } from '@angular/core';
import { take } from 'rxjs';


@Directive({
  // eslint-disable-next-line @angular-eslint/directive-selector
  selector: 'asl-google-signin-buttonm',
})
export class GoogleSigninButtonDirective {
  @Input()
  type: 'icon' | 'standard' = 'icon';

  @Input('selectable') option: boolean | any;

  constructor(private el: ElementRef, private socialAuthService: SocialAuthService) {
  }

  ngOnInit() {
    if (!this.option) return;
    this.socialAuthService.initState.pipe(take(1)).subscribe(() => {

    });
  }

}

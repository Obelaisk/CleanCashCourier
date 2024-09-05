import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-profile-field',
  templateUrl: './profile-field.component.html'
})
export class ProfileFieldComponent {
  @Input() title: string = '';
  @Input() value: string | Date = '';
}

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountAuthComponent } from './account-auth.component';

describe('AccountAuthComponent', () => {
  let component: AccountAuthComponent;
  let fixture: ComponentFixture<AccountAuthComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AccountAuthComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AccountAuthComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { CanActivateFn } from '@angular/router';
import { inject } from '@angular/core';
import { LoginService} from '../Services/Login/login.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

export const authguarddetailGuard: CanActivateFn = (route, state) => {
  const empService = inject(LoginService);
  const router = inject(Router);
  const toast = inject(ToastrService);

  if (empService.IsLogin()) {
    return true;
  } else {
    toast.error('Please Login First', 'Error', {
    closeButton: true,   // Ensure close button is enabled
    timeOut: 5000        // Auto-dismiss after 5 seconds
  });
    router.navigate(['account-auth']);
    return false;
  }
};

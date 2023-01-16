import { MenuItem } from '../models/menu.model';

export class Menu {
  public static pages: MenuItem[] = [
    {
      group: 'Home',
      separator: false,
      items: [
        {
          icon: 'assets/icons/outline/chart-pie.svg',
          label: 'Dashboard',
          route: '/dashboard',
          children: [
            { label: 'Biodata', route: '/dashboard/nfts' },
            { label: 'Biometric Registration', route: '/dashboard/nfts' },
            { label: 'Alumni Details', route: '/dashboard/nfts' }

          ],
        },
        /* {
          icon: 'assets/icons/outline/lock-closed.svg',
          label: 'Auth',
          route: '/auth',
          children: [
            { label: 'Sign up', route: '/auth/sign-up' },
            { label: 'Sign in', route: '/auth/sign-in' },
            { label: 'Forgot Password', route: '/auth/forgot-password' },
            { label: 'New Password', route: '/auth/new-password' },
            { label: 'Two Steps', route: '/auth/two-steps' },
          ],
        }, */
      ],
    },
    {
      group: 'Academics',
      separator: true,
      items: [
        {
          icon: 'assets/icons/outline/download.svg',
          label: 'Option Change',
          route: '/download',
        },
        {
          icon: 'assets/icons/outline/download.svg',
          label: 'Registration',
          route: '/download',
        },
        {
          icon: 'assets/icons/outline/download.svg',
          label: 'Statement of Result',
          route: '/download',
        },
        {
          icon: 'assets/icons/outline/gift.svg',
          label: 'Official Documents',
          route: '/gift',
        },
        {
          icon: 'assets/icons/outline/gift.svg',
          label: 'Clarence',
          route: '/gift',
        },
        {
          icon: 'assets/icons/outline/gift.svg',
          label: 'Virtual Classroom',
          route: '/gift',
        },

      ],
    },
    {
      group: 'Liaison',
      separator: true,
      items: [
        {
          icon: 'assets/icons/outline/download.svg',
          label: 'Attachment Letter',
          route: '/download',
        },
        {
          icon: 'assets/icons/outline/gift.svg',
          label: 'Semester Out',
          route: '/gift',
        },
        {
          icon: 'assets/icons/outline/users.svg',
          label: 'Assumption of Duty',
          route: '/users',
        },
      ],
    },
    {
      group: 'Finance',
      separator: false,
      items: [
        {
          icon: 'assets/icons/outline/cog.svg',
          label: 'Bills',
          route: '/settings',
        },
        {
          icon: 'assets/icons/outline/cog.svg',
          label: 'Pay Fees',
          route: '/settings',
        },
        {
          icon: 'assets/icons/outline/bell.svg',
          label: 'Payments',
          route: '/gift',
        },

      ],
    },
  ];
}

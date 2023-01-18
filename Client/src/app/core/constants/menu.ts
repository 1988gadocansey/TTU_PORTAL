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

      ],
    },
    {
      group: 'Academics',
      separator: false,
      items: [
        {
          icon: 'assets/icons/outline/chart-pie.svg',
          label: 'Academics',
          route: '/academics',
          children: [
            { label: 'Course Registration', route: '/academics/registration' },
            { label: 'Option Change', route: '/download', },
            { label: 'Statement of Result', route: '/download', }

          ],
        },

      ],
    },
    /* {
      group: 'Academics',
      separator: false,
      items: [
        {
          icon: 'assets/icons/outline/download.svg',
          label: 'Option Change',
          route: '/download',
        },
        {
          icon: 'assets/icons/outline/download.svg',
          label: 'Registration',
          route: '/academics/registration',
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
    }, */
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

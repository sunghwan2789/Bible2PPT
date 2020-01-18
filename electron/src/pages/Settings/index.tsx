import React from 'react';
import Page from '../Page';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCog } from '@fortawesome/free-solid-svg-icons';

const settingsPage: Page = {
  path: '/settings',
  title: '설정',
  icon: () => <FontAwesomeIcon icon={faCog} />,
  component: () => <></>,
};

export default settingsPage;

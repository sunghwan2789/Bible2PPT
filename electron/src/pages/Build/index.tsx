import React from 'react';
import Page from '../Page';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faDesktop } from '@fortawesome/free-solid-svg-icons';

const buildPage: Page = {
  path: '/build',
  title: 'PPT 만들기',
  icon: () => <FontAwesomeIcon icon={faDesktop} />,
  component: () => <></>,
};

export default buildPage;

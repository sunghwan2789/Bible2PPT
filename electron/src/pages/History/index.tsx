import React from 'react';
import Page from '../Page';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faHistory } from '@fortawesome/free-solid-svg-icons';

const historyPage: Page = {
  path: '/history',
  title: 'PPT 제작 기록',
  icon: () => <FontAwesomeIcon icon={faHistory} />,
  component: () => <></>,
};

export default historyPage;

import React from 'react';
import {
  MemoryRouter as Router,
  NavLink,
  Route,
  Switch,
} from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faDesktop, faHistory, faCog } from '@fortawesome/free-solid-svg-icons';
import './App.scss';

export default () => (
  <Router>
    <div className="app">
      <nav className="activity-bar">
        <div className="composite">
          <NavLink
            to="/"
            exact
            className="item"
            activeClassName="active"
            title="PPT 만들기"
          >
            <FontAwesomeIcon icon={faDesktop} />
          </NavLink>
          <NavLink
            to="/history"
            className="item"
            activeClassName="active"
            title="PPT 제작 기록"
          >
            <FontAwesomeIcon icon={faHistory} />
          </NavLink>
        </div>
        <div className="global">
          <NavLink
            to="/settings"
            className="item"
            activeClassName="active"
            title="설정"
          >
            <FontAwesomeIcon icon={faCog} />
          </NavLink>
        </div>
      </nav>
      <Switch>
        <Route path="/" exact>
          <p>build</p>
        </Route>
        <Route path="/history">
          <p>history</p>
        </Route>
        <Route path="/settings">
          <p>settings</p>
        </Route>
        <Route>404</Route>
      </Switch>
    </div>
  </Router>
);

import React from 'react';
import {
  MemoryRouter as Router,
  NavLink,
  Route,
  Switch,
  Redirect,
} from 'react-router-dom';
import Build from './pages/Build';
import History from './pages/History';
import Settings from './pages/Settings';

export default () => (
  <Router>
    <div className="app">
      <nav className="activity-bar">
        {Object.entries({
          composite: [Build, History],
          global: [Settings],
        }).map((kv, i) => {
          const [group, pages] = kv;
          return (
            <div key={i} className={group}>
              {pages.map((page, j) => (
                <NavLink
                  key={j}
                  className="item"
                  activeClassName="active"
                  to={page.path}
                  title={page.title}
                >
                  {page.icon}
                </NavLink>
              ))}
            </div>
          );
        })}
      </nav>
      <Switch>
        {/* 로드 후 PPT 만들기로 자동 전환 */}
        <Route path="/" exact>
          <Redirect to={Build.path} />
        </Route>
        <Route path={Build.path}>{Build.component}</Route>
        <Route path={History.path}>{History.component}</Route>
        <Route path="/settings">
          <p>settings</p>
        </Route>
        <Route>404</Route>
      </Switch>
    </div>
  </Router>
);

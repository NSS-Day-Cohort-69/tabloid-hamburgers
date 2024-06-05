import { useEffect, useState } from "react";
import { deactivateUser, getDeactivatedProfiles, getProfiles, reactivateUser } from "../../managers/userProfileManager";

import { Link } from "react-router-dom";


export default function UserProfileList() {
  const [userprofiles, setUserProfiles] = useState([]);
  const [filteredUsers, setFilteredUsers] = useState(false);
  const [deactivatedProfiles, setDeactivatedProfiles] = useState([]);

  const getUserProfiles = () => {
    getProfiles().then(
      (gottenProfiles) => {
        gottenProfiles = gottenProfiles.sort(function (a, b) {
          if (a.userName.toLowerCase() < b.userName.toLowerCase()) {
            return -1;
          }
          if (a.userName.toLowerCase() > b.userName.toLowerCase()) {
            return 1;
          }
          return 0;
        });
        setUserProfiles(gottenProfiles)
      }
    );
  };

  const getDeactivatedUsers = () => {
    getDeactivatedProfiles().then(
      (gottenProfiles) => {
        gottenProfiles = gottenProfiles.sort(function (a, b) {
          if (a.userName.toLowerCase() < b.userName.toLowerCase()) {
            return -1;
          }
          if (a.userName.toLowerCase() > b.userName.toLowerCase()) {
            return 1;
          }
          return 0;
        });
        setDeactivatedProfiles(gottenProfiles)
      }
    );
  }

  useEffect(() => {
    getUserProfiles();
    getDeactivatedUsers();
  }, []);

  const handleDeactivate = (event) => {
    if (window.confirm(`Confirm deactivation of: ${event.target.name}`)) {
      deactivateUser(event.target.value).then(() => {
        getUserProfiles();
        getDeactivatedUsers();
      });
    }
  };

  const handleReactivate = (event) => {
    if (window.confirm(`Confirm Reactivation of: ${event.target.name}`)) {
      reactivateUser(event.target.value).then(() => {
        getUserProfiles();
        getDeactivatedUsers();
      });
    }
  };

  const handleFilterChange = (event) => {
    
    if (event.target.checked) {
      setUserProfiles(deactivatedProfiles);
    }
    else {
      getUserProfiles();
    }
  };


  return (
    <>
      <h3>User Profile List</h3>
      <label>
        <input
          type="checkbox"
          defaultChecked={false}
          onChange={handleFilterChange}
        />
        View Deactivated Only
      </label>
      {userprofiles.map((p) => (

        <div key={p.id}>
          <p >
            {p.firstName} {p.lastName} {p.userName} {p.roles.includes("Admin") ? "admin" : "author"}
            <Link to={`/userprofiles/${p.id}`}>Details</Link>

          </p>

          {!p.isDeactivated && !p.roles.includes("Admin") && (
            <button name={p.userName} value={p.id} onClick={handleDeactivate}>
              Deactivate
            </button>
          )}
          {p.isDeactivated && !p.roles.includes("Admin") && (
            <button name={p.userName} value={p.id} onClick={handleReactivate}>
              Reactivate
            </button>
          )}

        </div>
      ))}
    </>
  );
}

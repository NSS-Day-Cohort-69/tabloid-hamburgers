import { useEffect, useState } from "react";
import { demoteProfile, getProfiles, promoteProfile, deactivateUser } from "../../managers/userProfileManager";
import { Link } from "react-router-dom";


export default function UserProfileList()
{
  const [userprofiles, setUserProfiles] = useState([]);


  const getUserProfiles = () =>
  {
    getProfiles().then(
      (gottenProfiles) =>
      {
        gottenProfiles = gottenProfiles.sort(function (a, b)
        {
          if(a.userName.toLowerCase() < b.userName.toLowerCase())
          {
            return -1;
          }
          if(a.userName.toLowerCase() > b.userName.toLowerCase())
          {
            return 1;
          }
          return 0;
        });
        setUserProfiles(gottenProfiles)
      }
    );
  };
  useEffect(() =>
  {
    getUserProfiles();
  }, []);

  const promoteClicked = (userId) =>
  {
    promoteProfile(userId).then(getUserProfiles)
  }

  const demoteClicked = (userId) =>
  {
    demoteProfile(userId).then(getUserProfiles)
  }

  const handleDeactivate = (event) =>
  {
    if(window.confirm(`Confirm deactivation of: ${event.target.name}`))
    {
      deactivateUser(event.target.value).then(() => getUserProfiles());
    }
  };
  return (
    <>
      <p>User Profile List</p>
      {userprofiles.map((p) => (
        <div key={p.id}>
          <p>
            {p.firstName} {p.lastName} {p.userName} {p.roles.includes("Admin") ? "admin" : "author"}
            <Link to={`/userprofiles/${p.id}`}>Details</Link>
            {
              p.roles.includes("Admin")
                ? <button onClick={() => demoteClicked(p.identityUserId)}>Demote</button>
                : <button onClick={() => promoteClicked(p.identityUserId)}>Promote</button>
            }
          </p>
          {!p.isDeactivated && !p.roles.includes("Admin") && (
            <button name={p.userName} value={p.id} onClick={handleDeactivate}>
              Deactivate
            </button>
          )}
        </div>
      ))}
    </>
  );
}

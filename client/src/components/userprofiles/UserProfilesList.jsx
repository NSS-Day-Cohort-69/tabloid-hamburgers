import { useEffect, useState } from "react";
import { getProfiles } from "../../managers/userProfileManager";
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
          if(a.userName < b.userName)
          {
            return -1;
          }
          if(a.userName > b.userName)
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
  return (
    <>
      <p>User Profile List</p>
      {userprofiles.map((p) => (
        <p key={p.id}>
          {p.firstName} {p.lastName} {p.userName} {p.roles.includes("Admin") ? "admin" : "author"}
          <Link to={`/userprofiles/${p.id}`}>Details</Link>
        </p>
      ))}
    </>
  );
}

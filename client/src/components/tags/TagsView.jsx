import { useEffect, useState } from "react";
import { getAllTags } from "../../managers/tags";

export const TagsView = () => {
  const [allTags, setAllTags] = useState([]);

  useEffect(() => {
    getAllTags().then(setAllTags);
  }, []);

  return (
    <main>
      <div>
        {allTags.map((t) => {
          return <article key={t.id}>{t.tagName}</article>;
        })}
      </div>
    </main>
  );
};

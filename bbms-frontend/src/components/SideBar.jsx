
import { Link, useNavigate } from 'react-router-dom'

function SideBar() {
  const navigate = useNavigate()
  const role = sessionStorage.getItem('role')
  console.log('Role ', role)

  const logout = () => {
    sessionStorage.clear()
    navigate('/')
  }
  return (
    <div className='list-group list-group-flush'>
      {role === 'Admin' ? (
        <>
          <Link
            to='/dashboard'
            className='list-group-item list-group-item-action p-2 text-left'
          >
            Dashboard
          </Link>
          <Link
            to='/bloodbanks'
            className='list-group-item list-group-item-action p-2 text-left'
          >
            Blood Banks
          </Link>
          <Link
            to='/donors'
            className='list-group-item list-group-item-action p-2 text-left'
          >
            Donors
          </Link>
          <Link
            to='/bloodbags'
            className='list-group-item list-group-item-action p-2 text-left'
          >
            Blood Bags
          </Link>
          <Link
            to='/recipients'
            className='list-group-item list-group-item-action p-2 text-left'
          >
            Recipients
          </Link>
        </>
      ) : (
        <>
          <Link
            to='/chome'
            className='list-group-item list-group-item-action p-2 text-left'
          >
            Home
          </Link>          
          <Link
            to='/thistory'
            className='list-group-item list-group-item-action p-2 text-left'
          >
            Transaction History
          </Link>
        </>
      )}      
      <button
        onClick={() => logout()}
        className='btn-link list-group-item list-group-item-action p-2 text-left'
      >
        Logout
      </button>
    </div>
  )
}

export default SideBar
